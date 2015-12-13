<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="European2012Standings.aspx.cs" Inherits="janlundholm.eu.European2012Standings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
	<link href="/Css/visualize/visualize.css" rel="stylesheet" type="text/css" />
	<link href="/Css/visualize/visualize-dark.css" rel="stylesheet" type="text/css" />
	<%--<link href="/Css/visualize/visualize-light.css" rel="stylesheet" type="text/css" />--%>
	<script src="JavaScript/jquery.js" type="text/javascript"></script>
	<script src="JavaScript/jquery.visualize.js" type="text/javascript"></script>
	<!--[if IE]><script type="text/javascript" src="excanvas.compiled.js"></script><![endif]-->
	<script src="JavaScript/jquery.jl.european2012Standings.js" type="text/javascript"></script>
</asp:Content>

<%--<asp:Content ID="Content2" ContentPlaceHolderID="Header" runat="server">
</asp:Content>--%>

<asp:Content ID="Content3" ContentPlaceHolderID="Content" runat="server">
	<h2>Aktuell ställning</h2>
	<%--<p>
		Gusav visar klass och rycker något. Men, vilken skräll, för första gången är Janne inte sist.</p>--%>
		
	<table style="display:block;">
		<caption style="display:none;">Poängställning</caption>
		<thead>
			<tr>
				<td></td>
				<th>7/6</th>
				<th>8/6</th>
				<th>8/6</th>
				<th>10/6</th>
				<th>11/6</th>
				<th>12/6</th>
				<th>13/6</th>
				<th>14/6</th>
				<th>15/6</th>
				<th>16/6</th>
				<th>17/6</th>
				<th>18/6</th>
				<th>19/6</th>
				<th>21/6</th>
				<th>22/6</th>
				<th>23/6</th>
				<th>24/6</th>
				<th>27/6</th>
				<th>28/6</th>
				<th>1/7</th>
			</tr>
		</thead>
		<tbody>
			<tr>
				<th>Daniel</th>
				<td class="numeric">0</td>
				<td class="numeric">4</td>
				<td class="numeric">10</td>
				<td class="numeric">16</td>
				<td class="numeric">18</td>
				<td class="numeric">21</td>
				<td class="numeric">22</td>
				<td class="numeric">26</td>
				<td class="numeric">27</td>
				<td class="numeric">32</td>
				<td class="numeric">40</td>
				<td class="numeric">58</td>
				<td class="numeric">66</td>
				<td class="numeric">66</td>
				<td class="numeric">74</td>
				<td class="numeric">74</td>
				<td class="numeric">74</td>
				<td class="numeric">74</td>
				<td class="numeric">74</td>
				<td class="numeric">74</td>
			</tr>
			<tr>
				<th>Denise</th>
				<td class="numeric">0</td>
				<td class="numeric">5</td>
				<td class="numeric">9</td>
				<td class="numeric">12</td>
				<td class="numeric">13</td>
				<td class="numeric">19</td>
				<td class="numeric">20</td>
				<td class="numeric">25</td>
				<td class="numeric">29</td>
				<td class="numeric">37</td>
				<td class="numeric">46</td>
				<td class="numeric">64</td>
				<td class="numeric">73</td>
				<td class="numeric">73</td>
				<td class="numeric">81</td>
				<td class="numeric">89</td>
				<td class="numeric">89</td>
				<td class="numeric">105</td>
				<td class="numeric">105</td>
				<td class="numeric">129</td>
			</tr>
			<tr>
				<th>Gustav</th>
				<td class="numeric">0</td>
				<td class="numeric">4</td>
				<td class="numeric">8</td>
				<td class="numeric">18</td>
				<td class="numeric">19</td>
				<td class="numeric">23</td>
				<td class="numeric">28</td>
				<td class="numeric">33</td>
				<td class="numeric">38</td>
				<td class="numeric">39</td>
				<td class="numeric">50</td>
				<td class="numeric">68</td>
				<td class="numeric">75</td>
				<td class="numeric">75</td>
				<td class="numeric">83</td>
				<td class="numeric">91</td>
				<td class="numeric">91</td>
				<td class="numeric">107</td>
				<td class="numeric">107</td>
				<td class="numeric">107</td>
			</tr>
			<tr>
				<th>Janne</th>
				<td class="numeric">0</td>
				<td class="numeric">4</td>
				<td class="numeric">7</td>
				<td class="numeric">10</td>
				<td class="numeric">11</td>
				<td class="numeric">15</td>
				<td class="numeric">20</td>
				<td class="numeric">25</td>
				<td class="numeric">30</td>
				<td class="numeric">31</td>
				<td class="numeric">40</td>
				<td class="numeric">58</td>
				<td class="numeric">69</td>
				<td class="numeric">69</td>
				<td class="numeric">77</td>
				<td class="numeric">85</td>
				<td class="numeric">85</td>
				<td class="numeric">101</td>
				<td class="numeric">101</td>
				<td class="numeric">125</td>
			</tr>
			<tr>
				<th>Peter</th>
				<td class="numeric">0</td>
				<td class="numeric">9</td>
				<td class="numeric">9</td>
				<td class="numeric">13</td>
				<td class="numeric">14</td>
				<td class="numeric">17</td>
				<td class="numeric">18</td>
				<td class="numeric">24</td>
				<td class="numeric">31</td>
				<td class="numeric">37</td>
				<td class="numeric">43</td>
				<td class="numeric">56</td>
				<td class="numeric">69</td>
				<td class="numeric">69</td>
				<td class="numeric">77</td>
				<td class="numeric">85</td>
				<td class="numeric">85</td>
				<td class="numeric">101</td>
				<td class="numeric">101</td>
				<td class="numeric">101</td>
			</tr>
			<tr>
				<th>Rickard</th>
				<td class="numeric">0</td>
				<td class="numeric">4</td>
				<td class="numeric">7</td>
				<td class="numeric">12</td>
				<td class="numeric">12</td>
				<td class="numeric">16</td>
				<td class="numeric">22</td>
				<td class="numeric">31</td>
				<td class="numeric">32</td>
				<td class="numeric">32</td>
				<td class="numeric">42</td>
				<td class="numeric">60</td>
				<td class="numeric">68</td>
				<td class="numeric">68</td>
				<td class="numeric">76</td>
				<td class="numeric">84</td>
				<td class="numeric">84</td>
				<td class="numeric">84</td>
				<td class="numeric">84</td>
				<td class="numeric">84</td>
			</tr>
		</tbody>
	</table>
	
	<%--<table >
		<caption>2009 Individual Sales by Category</caption>
		<thead>
			<tr>
				<td></td>
				<th>food</th>
				<th>auto</th>
				<th>household</th>
				<th>furniture</th>
				<th>kitchen</th>
				<th>bath</th>
			</tr>
		</thead>
		<tbody>
			<tr>
				<th>Mary</th>
				<td>150</td>
				<td>160</td>
				<td>40</td>
				<td>120</td>
				<td>30</td>
				<td>70</td>
			</tr>
			<tr>
				<th>Tom</th>
				<td>3</td>
				<td>40</td>
				<td>30</td>
				<td>45</td>
				<td>35</td>
				<td>49</td>
			</tr>
		</tbody>
	</table>--%>
	
</asp:Content>

<%--<asp:Content ID="Content4" ContentPlaceHolderID="Footer" runat="server">
</asp:Content>
--%>